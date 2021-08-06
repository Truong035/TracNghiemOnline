// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable();
    $('#add-row').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'excel', 'pdf', 'print'
        ]
    });
});
