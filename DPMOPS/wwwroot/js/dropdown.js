$(document).ready(function () {
    $('#citySelect').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON('?handler=DistrictsByCity&cityId=' + cityId, function (data) {
                var districtSelect = $('#districtSelect');
                districtSelect.empty();
                districtSelect.append($('<option/>').val('').text(' '));
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

$(document).ready(function () {
    $('#citySelect').change(function () {
        var cityId = $(this).val();
        if (cityId) {
            $.getJSON('?handler=OrgsByCity&cityId=' + cityId, function (data) {
                var orgSelect = $('#orgSelect');
                orgSelect.empty();
                orgSelect.append($('<option/>').val('').text(' '));
                $.each(data, function (index, item) {
                    orgSelect.append($('<option/>').val(item.value).text(item.text));
                });
                orgSelect.prop('disabled', false);
            });
        } else {
            $('#orgSelect').empty().prop('disabled', true);
        }
    });
});