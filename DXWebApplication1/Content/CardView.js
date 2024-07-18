function onPageToolbarItemClick(s, e) {
    switch (e.item.name) {
        case "New":
            CardView.AddNewCard();
            break;
        case "Edit":
            CardView.StartEditCard(CardView.GetFocusedCardIndex());
            break;
        case "Delete":
            console.log("socorro");
            deleteSelectedRecords();
            break;
        case "Export":
            CardView.ExportTo(ASPxClientCardViewExportFormat.Xlsx);
            break;
    }
}
function deleteSelectedRecords() {
    console.log("aaaaa");
    if (confirm('Confirm Delete?')) {
        var id = CardView.GetFocusedCardIndex();
        console.log(id);
        var p = CardView.GetCardKey(id);
        console.log(p);
        CardView.DeleteCardByKey(p);

    }
}

function onFilterPanelExpanded() {
    console.log("Entrou");
}

function adjustPageControls() {
    console.log("Entrou no panel");
}
