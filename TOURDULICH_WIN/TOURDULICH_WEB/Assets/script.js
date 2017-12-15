

$(document).ready(function () {
    $('#dataTables-example').DataTable({
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Vietnamese.json"
        }
    });
 
   
    $(document).on('keyup','.notoida', function () {
        $(this).val($(this).val().replace(/([a-zA-z])+/g, ''));
       
    });

  
});
function FormatCurrency(num) {

    //So khớp số 1 số trong chuỗi khi 1 số sau nó(?=) lấy đc 3 số
    var n = num.toFixed(1).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    var cur = n.split(".");
    return cur[0];
}

$(window).on('load', function () {
    
    $('.money').each(function () {
        $(this).text(FormatCurrency(parseInt($(this).text())));
        console.log('ok');
    });
    
});

//Validate daily them sua
$(document).on("click", ".myform", function (e) {
    $(this).validate({
        errorClass: "my-error-class",

        rules: {
            tendl: {
                required: true,
            },
            diachi: { required: true },
            email: { required: true, email: true },
            sdt: { required: true, number: true },
            notoida: { required: true, number: true }
        },
        messages: {
            tendl: {
                required: "Nhập tên đại lý",
            },
            diachi: { required: 'Nhập địa chỉ' },
            email: { required: "Nhập email", email: "Email không hợp lệ" },
            sdt: { required: "Nhập số điện thoại", number: "Chỉ nhập số" },
            notoida: { required: "Nhập tổng nợ tối đa", number: "Chỉ nhập số" }
        }
    });
});

$(document).on("click", ".myform_nhap", function (e) {
    $(this).validate({
        errorClass: "my-error-class",

        rules: {   
            soluong: { required: true, number: true },
           
        },
        messages: {  
            soluong: { required: "Nhập số lượng", number: "Chỉ nhập số" },
        }
    });
});