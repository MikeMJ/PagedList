function goToPage(pageNumber) {
    document.getElementById("hdnPageNumber").value = pageNumber;
    document.getElementById("btnSubmit").click();
}