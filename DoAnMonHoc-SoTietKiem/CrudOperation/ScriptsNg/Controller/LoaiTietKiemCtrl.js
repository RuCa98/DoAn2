
app.controller('LoaiTietKiemCtrl', ['$scope', 'CrudService',
    function ($scope, CrudService) {

        // Base Url 
        var baseUrl = '/api/LoaiTietKiem/';
        $scope.btnText = "Thêm mới";
        $scope.ID = 0;
        $scope.SaveUpdate = function () {
            var loaitietkiem = {
                TenLoaiTietKiem: $scope.tenloaitietkiem,
                MoTa: $scope.mota,
                ID: $scope.id
            }
            if ($scope.btnText == "Thêm mới") {
                var apiRoute = baseUrl + 'SaveLoaiTietKiem/';
                var saveLoaiTietKiem = CrudService.post(apiRoute, loaitietkiem);
                saveLoaiTietKiem.then(function (response) {
                    if (response.data != "") {
                        alert("Thêm mới thành công!");
                        $scope.GetLoaiTietKiems();
                        $scope.Clear();

                    } else {
                        alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else
            {
                var apiRoute = baseUrl + 'UpdateLoaiTietKiem/';
                var UpdateLoaiTietKiem = CrudService.put(apiRoute, loaitietkiem);
                UpdateLoaiTietKiem.then(function (response) {
                    if (response.data != "") {
                        alert("Cập nhật thành công!");
                        $scope.GetLoaiTietKiems();
                        $scope.Clear();

                    } else {
                        alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }


        $scope.GetLoaiTietKiems = function () {
            var apiRoute = baseUrl + 'GetLoaiTietKiems/';
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
        
        $scope.GetLoaiTietKiemByID = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'GetLoaiTietKiemByID';
            var loaitietkiem = CrudService.getbyID(apiRoute, dataModel.ID);
            loaitietkiem.then(function (response) {
                $scope.id = response.data.ID;
                $scope.tenloaitietkiem = response.data.TenLoaiTietKiem;
                $scope.mota = response.data.MoTa;
                $scope.btnText = "Cập nhật";
            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.DeleteLoaiTietKiem = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'DeleteLoaiTietKiem/' + dataModel.ID;
            var deleteLoaiTietKiem = CrudService.delete(apiRoute);
            deleteLoaiTietKiem.then(function (response) {
                if (response.data != "") {
                    alert("Xóa thành công!");
                    $scope.GetLoaiTietKiems();
                    $scope.Clear();

                } else {
                    alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
                }

            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.Clear = function () {
            $scope.ID = 0;
            $scope.tenloaitietkiem = "";
            $scope.mota = "";
            $scope.btnText = "Thêm mới";
        }

    }]);