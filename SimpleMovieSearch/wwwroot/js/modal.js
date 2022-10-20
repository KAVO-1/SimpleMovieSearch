function openModal(parameters) {
    const id = parameters.data;
    const url = parameters.url;
    const modal = $('#modal');

    if (id === undefined || url === undefined) {
        alert('Error')
        return;
    }

    $.ajax({
        type: 'GET',
        url: url,
        data: { "id": id },
        success: function (resp) {
            modal.find(".modal-body").html(resp);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (resp) {
            alert(resp.respText);
        }
    });
};