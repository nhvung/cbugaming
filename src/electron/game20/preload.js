const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    getScripts: () => ipcRenderer.invoke('get-scripts'),
    browseScripts: () => ipcRenderer.invoke('browse-scripts'),
    removeScript: (path) => ipcRenderer.invoke('remove-script', path),
    runScripts: (paths) => ipcRenderer.invoke('run-scripts', paths)
});
