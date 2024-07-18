function onPageToolbarItemClick(s, e) {
        switch (e.item.name) {
            case "New":
                gridView.AddNewRow();
                break;
            case "Edit":
                gridView.StartEditRow(gridView.GetFocusedRowIndex());
                break;
            case "Delete":
                console.log("socorro");
                deleteSelectedRecords();
                break;
            case "Export":
                gridView.ExportTo(ASPxClientGridViewExportFormat.Xlsx);
                break;
        }
    }
    function deleteSelectedRecords() {
        console.log("aaaaa");
        if (confirm('Confirm Delete?')) {
            var id = gridView.GetFocusedRowIndex();
            console.log(id);
            var p = gridView.GetRowKey(id);
            console.log(p);
            gridView.DeleteRowByKey(p);

        }
}

function onFilterPanelExpanded() {
    console.log("Entrou");
}

function adjustPageControls() {
    console.log("Entrou no panel");
}
