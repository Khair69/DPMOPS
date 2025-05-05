$(document).ready(function () {
    $('#citySelect').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON('?handler=DistrictsByCity&cityId=' + cityId, function (data) {
                var districtSelect = $('#districtSelect');
                districtSelect.empty();
                districtSelect.append($('<option/>').val('').text('-- Select District --'));
                $.each(data, function (index, item) {
                    districtSelect.append($('<option/>').val(item.value).text(item.text));
                });
                districtSelect.prop('disabled', false);
            });
        } else {
            $('#districtSelect').empty().prop('disabled', true);
        }
    });
});