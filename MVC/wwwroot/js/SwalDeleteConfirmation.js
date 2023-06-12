function confirmDelete(link) {
    return Swal.fire({
        title: 'Silmek İstediğinize Emin misiniz?',
        text: "",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'İptal',
        confirmButtonText: 'Sil!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = link;
        }
    });
}