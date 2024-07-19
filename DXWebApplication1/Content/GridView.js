function onPageToolbarItemClick(s, e) {
    switch (e.item.name) {
        case "ToggleFilterPanel":
            toggleFilterPanel();
            break;
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

function onGridViewRowDblClick(s, e) {
    s.StartEditRow(e.visibleIndex);
    console.log(e);
}

function toggleFilterPanel() {
    console.log("baiacu");
    filterPanel.Toggle();
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

function onFilterPanelExpanded(s, e) {
    console.log("Entrou");
    adjustPageControl();
    searchButtonEdit.SetFocus();
    
}

window.onPageToolbarItemClick = onPageToolbarItemClick;
window.onFilterPanelExpanded = onFilterPanelExpanded;