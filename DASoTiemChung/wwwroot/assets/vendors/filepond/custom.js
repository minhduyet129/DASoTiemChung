// Register the plugin
FilePond.registerPlugin(FilePondPluginImageExifOrientation);
FilePond.registerPlugin(FilePondPluginImagePreview);
FilePond.setOptions({
    credits: false,
    server: {
        url: nami.clientConfiguration.filePond.server.url,
        process: nami.clientConfiguration.filePond.server.process,
        revert: nami.clientConfiguration.filePond.server.revert,
        load: nami.clientConfiguration.filePond.server.load,
        restore: nami.clientConfiguration.filePond.server.restore,
        fetch: nami.clientConfiguration.filePond.server.fetch,
        patch: nami.clientConfiguration.filePond.server.patch,
        remove: nami.clientConfiguration.filePond.server.remove,
    },
    allowDrop: true,
    allowBrowse: true,
    allowPaste: true,
    allowMultiple: false,
    allowReplace: true,
    allowRevert: true,
    allowRemove: true,
    allowProcess: true,
    allowReorder: true,
    //labelIdle: '<span class="filepond--label-action">Duyệt ảnh</span>'
});