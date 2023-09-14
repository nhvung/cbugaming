using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSSystem.Management.Windows;

namespace game5
{
    public partial class MainF : Form
    {
        DelegateProcess _dlg;
        CheckBox _chkall;
        object _lockExecuteObj;
        Dictionary<string, DataGridViewStatusCell.StatusCell> _cellStatus;
        Dictionary<int, KeyValuePair<DateTime, TimeSpan>> _mCpuProcessTime;
        public MainF()
        {
            InitializeComponent();
            _dlg = new DelegateProcess();
            _chkall = _dlg.AddDataGridViewCheckBoxAll(dgv_services, "dgv_service_col_chk");
            _lockExecuteObj = new object();
            try
            {
                Icon = Icon.FromHandle(Properties.Resources.icon.GetHicon());
                if (!SystemInformation.TerminalServerSession)
                {
                    Type dgvType = dgv_services.GetType();
                    PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                    pi.SetValue(dgv_services, true, null);
                }
                _cellStatus = new Dictionary<string, DataGridViewStatusCell.StatusCell>(StringComparer.InvariantCultureIgnoreCase)
                {
                    { "Stopped", new  DataGridViewStatusCell.StatusCell(){ Value = "Stopped", BackColor = Color.DarkRed, ForeColor = Color.White } },
                    { "Running", new  DataGridViewStatusCell.StatusCell()  { Value = "Running", BackColor = Color.FromArgb(0,176,80), ForeColor = Color.White }},
                    { "Starting", new  DataGridViewStatusCell.StatusCell()  { Value = "Starting", BackColor = Color.Transparent, ForeColor = Color.Black }},
                    { "Stopping", new  DataGridViewStatusCell.StatusCell()  { Value = "Stopping", BackColor = Color.Transparent, ForeColor = Color.Black }},
                    { "Uninstalling", new  DataGridViewStatusCell.StatusCell()  { Value = "Uninstalling", BackColor = Color.Orange, ForeColor = Color.Black }},
                    { "Uninstalled", new  DataGridViewStatusCell.StatusCell()  { Value = "Uninstalled", BackColor = Color.Orange, ForeColor = Color.Black }},
                };
            }
            catch { }

#if DEBUG
            ts_menu_prename.Text = "bs";
#endif

        }

        void _updateStatus(string status)
        {
            _dlg.Execute(ss_menu, delegate {
                ss_menu_status.Text = status;
            });
        }
        private void ts_menu_but_search_Click(object sender, EventArgs e)
        {
            try
            {
                _stopTimerRefresh = true;
                   var but = sender as ToolStripSplitButton;
                if(!but.DropDownButtonPressed)
                {

                    Task.Run(() => _searchServices());
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Task _searchServices()
        {
            try
            {
                lock (_lockExecuteObj)
                {
                    _stopTimerRefresh = true;
                    _mCpuProcessTime = new Dictionary<int, KeyValuePair<DateTime, TimeSpan>>();
                    _updateStatus("Searching...");
                    _dlg.ClearDataGridViewRows(dgv_services);
                    _dlg.Execute(_chkall, () => _chkall.Checked = false);

                    var sPreNames = _dlg.GetControlValue(ts_menu, ts_menu => ts_menu_prename.Text);
                    string[] preNames = null;
                    if (!string.IsNullOrWhiteSpace(sPreNames))
                    {
                        preNames = sPreNames.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    if (preNames?.Length > 0)
                    {
                        ServiceProcess sp = new ServiceProcess();
                        var serviceObjs = sp.GetServices(preNames?.ToList(), true, true);
                        if (serviceObjs?.Count > 0)
                        {
                            foreach (var serviceObj in serviceObjs)
                            {
                                string status = serviceObj.Status.ToString();

                                DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                                if (_cellStatus.ContainsKey(status))
                                {
                                    statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                                }
                                _dlg.AddDataGridViewRow(dgv_services, false, serviceObj.Name, serviceObj.WorkingFolderPath, statusCell, serviceObj.WorkingSet, "-");
                                if (serviceObj.Status == VSSystem.Management.Models.EStatus.Running)
                                {
                                    Process p = Process.GetProcessById(serviceObj.ProcessID);
                                    if(p!=null)
                                    {
                                        _mCpuProcessTime[p.Id] = new KeyValuePair<DateTime, TimeSpan>(DateTime.UtcNow, p.TotalProcessorTime);
                                    }
                                }
                                else
                                {
                                    
                                }
                                
                            }
                        }
                    }
                }
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _updateStatus("-");
            }
            return Task.CompletedTask;
        }
        Task _actionServices(List<DataGridViewRow> rowObjs, VSSystem.Management.Models.EAction action)
        {
            try
            {
                _updateStatus($"{action} services...");
                ServiceProcess sp = new ServiceProcess();
                foreach (var rowObj in rowObjs)
                {
                    string name = rowObj.Cells["dgv_service_col_name"].Value.ToString();
                    string status = string.Empty;

                   
                    try
                    {
                        try
                        {
                            if (action == VSSystem.Management.Models.EAction.Start)
                            {
                                status = "Starting";
                            }
                            else if (action == VSSystem.Management.Models.EAction.Stop)
                            {
                                status = "Stopping";
                            }
                            DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                            if (_cellStatus.ContainsKey(status))
                            {
                                statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                            }
                            rowObj.Cells["dgv_service_col_status"].Value = statusCell;
                        }
                        catch
                        {

                        }
                        try
                        {
                            sp.ActionService(name, action);

                            if (action == VSSystem.Management.Models.EAction.Start)
                            {
                                status = "Running";
                            }
                            else if (action == VSSystem.Management.Models.EAction.Stop)
                            {
                                status = "Stopped";
                            }
                            DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                            if (_cellStatus.ContainsKey(status))
                            {
                                statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                            }
                            rowObj.Cells["dgv_service_col_status"].Value = statusCell;
                        }
                        catch
                        {
                        }
                       

                    }
                    catch { }
                }
                _refreshServices(rowObjs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _updateStatus("-");
            }
            return Task.CompletedTask;
        }
        void ts_menu_but_start_Click(object sender, EventArgs e)
        {
            try
            {
                var rowObjs = _dlg.GetDataGridViewCheckedRows(dgv_services, "dgv_service_col_chk");
                if(rowObjs.Count==0)
                {
                    rowObjs = _dlg.GetDataGridViewSelectedRows(dgv_services);
                }
                if(rowObjs?.Count > 0)
                {
                    Task.Run(()=>_actionServices(rowObjs, VSSystem.Management.Models.EAction.Start));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        void ts_menu_but_stop_Click(object sender, EventArgs e)
        {
            try
            {
                var rowObjs = _dlg.GetDataGridViewCheckedRows(dgv_services, "dgv_service_col_chk");
                if (rowObjs.Count == 0)
                {
                    rowObjs = _dlg.GetDataGridViewSelectedRows(dgv_services);
                }
                if (rowObjs?.Count > 0)
                {
                    Task.Run(() => _actionServices(rowObjs, VSSystem.Management.Models.EAction.Stop));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        System.Timers.Timer _tmrRefreshServices;
        bool _stopTimerRefresh = false;
        void _refreshServices(List<DataGridViewRow> rowObjs)
        {
            try
            {
                lock (_lockExecuteObj)
                {
                    _updateStatus($"Auto refresh services...");
                    if (rowObjs?.Count > 0)
                    {
                        var names = rowObjs.Select(ite => ite.Cells["dgv_service_col_name"].Value.ToString()).ToList();
                        ServiceProcess sp = new ServiceProcess();
                        var serviceObjs = sp.GetServices(names, false, true);
                        if (serviceObjs?.Count > 0)
                        {
                            foreach (var rowObj in rowObjs)
                            {
                                try
                                {
                                    string name = rowObj.Cells["dgv_service_col_name"].Value.ToString();
                                    var serviceObj = serviceObjs.FirstOrDefault(ite => ite.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                                    if (serviceObj != null)
                                    {
                                        if (serviceObj.Status == VSSystem.Management.Models.EStatus.Running || serviceObj.Status == VSSystem.Management.Models.EStatus.Stopped)
                                        {
                                            string status = serviceObj.Status.ToString();
                                            DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                                            if (_cellStatus.ContainsKey(status))
                                            {
                                                statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                                            }
                                            rowObj.Cells["dgv_service_col_status"].Value = statusCell;
                                            rowObj.Cells["dgv_service_col_memory"].Value = serviceObj.WorkingSet;
                                            if (serviceObj.Status== VSSystem.Management.Models.EStatus.Running)
                                            {
                                                string cpuValue = _getCpuPercent(serviceObj.ProcessID);
                                                rowObj.Cells["dgv_service_col_cpu"].Value = cpuValue;
                                            }
                                        }

                                    }
                                }
                                catch
                                {

                                }

                            }
                        }
                    }
                }
                    
            }
            catch { }
            finally
            {
                _updateStatus("-");
            }
            
        }
        private void ts_menu_but_search_auto_5s_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                _searchServices();
                _autoRefresh(5);
            });
            
        }
        void _autoRefresh(int interval)
        {
            try
            {
                _stopTimerRefresh = false;
                _tmrRefreshServices?.Stop();
                _tmrRefreshServices = new System.Timers.Timer(interval*1000);
                _tmrRefreshServices.Elapsed += (o, e2) => {
                    _tmrRefreshServices.Stop();
                    try
                    {
                        var rowObjs = _dlg.GetDataGridViewRows(dgv_services);
                        _refreshServices(rowObjs);
                    }
                    catch
                    {

                    }
                    if (!_stopTimerRefresh)
                    {
                        _tmrRefreshServices.Start();
                    }

                };
                _tmrRefreshServices.Start();
            }
            catch
            {
            }
           
        }

        private void ts_menu_but_uninstall_Click(object sender, EventArgs e)
        {
            try
            {
                var rowObjs = _dlg.GetDataGridViewCheckedRows(dgv_services, "dgv_service_col_chk");
                if (rowObjs.Count == 0)
                {
                    rowObjs = _dlg.GetDataGridViewSelectedRows(dgv_services);
                }
                if(rowObjs?.Count > 0)
                {
                    if (MessageBox.Show("Do you want to do this?", "Uninstall Services", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Task.Run(() => _uninstallServices(rowObjs));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void _uninstallServices(List<DataGridViewRow> rowObjs)
        {
            try
            {
                ServiceProcess sp = new ServiceProcess();
                foreach (var rowObj in rowObjs)
                {

                    string name = rowObj.Cells["dgv_service_col_name"].Value.ToString();
                    sp.ActionService(name, VSSystem.Management.Models.EAction.Stop);
                    try
                    {
                        string status = "Uninstalling";
                        DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                        if (_cellStatus.ContainsKey(status))
                        {
                            statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                        }
                        rowObj.Cells["dgv_service_col_status"].Value = statusCell;
                    }
                    catch
                    {
                    }
                    
                    CLIExtension.Execute("sc.exe",new List<string>() {$"delete \"{name}\"" },false);
                    try
                    {
                        string status = "Uninstalled";
                        DataGridViewStatusCell.StatusCell statusCell = new DataGridViewStatusCell.StatusCell(status, Color.Transparent, Color.Black);
                        if (_cellStatus.ContainsKey(status))
                        {
                            statusCell = new DataGridViewStatusCell.StatusCell(status, _cellStatus[status].BackColor, _cellStatus[status].ForeColor);
                        }
                        rowObj.Cells["dgv_service_col_status"].Value = statusCell;
                    }
                    catch
                    {
                    }
                }
                Task.Run(_searchServices);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ts_menu_but_install_ButtonClick(object sender, EventArgs e)
        {
            ToolStripSplitButton but = sender as ToolStripSplitButton;
            if (!but.DropDownButtonPressed)
            {
                using (InstallF installF = new InstallF())
                {
                    if (installF.ShowDialog() == DialogResult.OK)
                    {
                        Task.Run(_searchServices);

                    }
                }
            }
        }

        private void ts_menu_but_install_multiple_Click(object sender, EventArgs e)
        {
            using (MultipleInstallF installF = new MultipleInstallF())
            {
                if (installF.ShowDialog() == DialogResult.OK)
                {
                    Task.Run(_searchServices);
                }
            }
        }

        string _getCpuPercent(int pid)
        {
            string result = "-";
            try
            {
                DateTime utcNow = DateTime.UtcNow;
                Process p = Process.GetProcessById(pid);
                if (_mCpuProcessTime.ContainsKey(pid))
                {
                    var pLastValue = _mCpuProcessTime[pid];
                    var timeDiff = (utcNow - pLastValue.Key).TotalMilliseconds;
                    var cpuUsage = (p.TotalProcessorTime - pLastValue.Value).TotalMilliseconds;
                    var cpuPercent = (cpuUsage * 100.0 / (Environment.ProcessorCount * timeDiff));
                    result = cpuPercent.ToString("0.0")+"%";
                }
                _mCpuProcessTime[pid] = new KeyValuePair<DateTime, TimeSpan>(utcNow, p.TotalProcessorTime);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
            
        }

        private void ts_menu_but_search_auto_1s_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                _searchServices();
                _autoRefresh(1);
            });
        }

        private void ts_menu_but_update_Click(object sender, EventArgs e)
        {
            var rowObjs = _dlg.GetDataGridViewCheckedRows(dgv_services, "dgv_service_col_chk");
            if (rowObjs.Count == 0)
            {
                rowObjs = _dlg.GetDataGridViewSelectedRows(dgv_services);
            }
            if (rowObjs?.Count > 0)
            {
                List<KeyValuePair<string, string>> serviceObjs = new List<KeyValuePair<string, string>>();
                serviceObjs = rowObjs.Select(ite => new KeyValuePair<string, string>(ite.Cells["dgv_service_col_name"].Value.ToString(), ite.Cells["dgv_service_col_folder"].Value.ToString())).ToList();
                using (UpdateF f = new UpdateF(serviceObjs))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
            
        }
    }
}
