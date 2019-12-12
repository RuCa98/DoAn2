
app.controller('TaiKhoanCtrl', ['$scope', 'CrudService',
    function ($scope, CrudService) {

        // Base Url 
        var baseUrl = '/api/TaiKhoan/';
        $scope.btnText = "Thêm mới";
        $scope.ID = 0;
        $scope.SaveUpdate = function () {
            var taikhoan = {
                TenKhachHang: $scope.TenKhachHang,
                SoCMND: $scope.socmnd,
                Email: $scope.email,
                DiaChi: $scope.diachi,
                SoDienThoai: $scope.sodienthoai,
                ID: $scope.ID
            }
            if ($scope.btnText == "Thêm mới") {
                var apiRoute = baseUrl + 'SaveTaiKhoan/';
                var saveTaiKhoan = CrudService.post(apiRoute, taikhoan);
                saveTaiKhoan.then(function (response) {
                    if (response.data != "") {
                        alert("Thêm mới thành công!");
                        $scope.GetTaiKhoans();
                        $scope.Clear();

                    } else {
                        alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else {
                var apiRoute = baseUrl + 'UpdateTaiKhoan/';
                var UpdateTaiKhoan = CrudService.put(apiRoute, taikhoan);
                UpdateTaiKhoan.then(function (response) {
                    if (response.data != "") {
                        alert("Cập nhật thành công!");
                        $scope.GetTaiKhoans();
                        $scope.Clear();

                    } else {
                        alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }


        $scope.GetTaiKhoans = function () {
            var apiRoute = baseUrl + 'GetTaiKhoans/';
            var TaiKhoan = CrudService.getAll(apiRoute);
            TaiKhoan.then(function (response) {
                $scope.taikhoans = response.data;

            },
            function (error) {
                console.log("Error: " + error);
            });


        }
        $scope.GetTaiKhoans();

        $scope.GetTaiKhoanByID = function (dataModel) {
            var apiRoute = baseUrl + 'GetLoaiTietKiemByID';
            var TaiKhoan = CrudService.getbyID(apiRoute, dataModel.TaiKhoanID);
            TaiKhoan.then(function (response) {
                $scope.ID = response.data.ID;
                $scope.firstName = response.data.FirstName;
                $scope.lasttName = response.data.LastName;
                $scope.email = response.data.Email;
                $scope.adress = response.data.Address;
                $scope.btnText = "Cập nhật";
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.DeleteTaiKhoan = function (dataModel) {
            debugger
            var apiRoute = baseUrl + 'DeleteTaiKhoan/' + dataModel.ID;
            var deleteTaiKhoan = CrudService.delete(apiRoute);
            deleteTaiKhoan.then(function (response) {
                if (response.data != "") {
                    alert("Xóa thành công!");
                    $scope.GetTaiKhoans();
                    $scope.Clear();

                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                }

            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetLoaiTietKiems = function () {
            var apiRoute = '/api/LoaiTietKiem/GetLoaiTietKiems/';
            var loaitietkiem = CrudService.getAll(apiRoute);
            loaitietkiem.then(function (response) {
                debugger
                $scope.loaitietkiems = response.data;

            },
                function (error) {
                    console.log("Error: " + error);
                });


        }
        $scope.GetLoaiTietKiems();

        $scope.Clear = function () {
            $scope.tenkhachhang = "",
            $scope.socmnd = "";
            $scope.email = "";
            $scope.diachi = "";
            $scope.sodienthoai = "";
            $scope.ID = 0;
            $scope.btnText = "Thêm mới";
        }

    }]);