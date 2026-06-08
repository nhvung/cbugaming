const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    openFile: () => ipcRenderer.invoke('open-file'),
    saveCSV: (content, suggestedName) => ipcRenderer.invoke('save-csv', { content, suggestedName }),
    writeFile: (filePath, content) => ipcRenderer.invoke('write-file', { filePath, content }),
    saveXlsx: (rows, suggestedName) => ipcRenderer.invoke('save-xlsx', { rows, suggestedName })
});
