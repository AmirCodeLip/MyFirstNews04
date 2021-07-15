(function () {

    this.onNgReady = function ($scope) {
        let fileUploader = (function () {
            let input = document.createElement("input");
            input.onchange = async (e) => {
                var form = new FormData();
                form.append("file", input.files[0]);
                let data = await fetch("/Admin/Upload/SaveFile", {
                    method: "post",
                    body: form
                });
                let jsonData = await data.json();

                $scope.$apply(function () {
                    $scope.files.push({
                        src: `/File/GetImg/${jsonData.Id}`
                    });



                });


            }



            input.type = "file";
            return input;
        }());


        $scope.uploadImage = function (e) {
            if (e.target.classList.contains("remove-parent")) {
                return;
            }
            else if (e.target.tagName === "IMG")
                return;






            fileUploader.click();
        };
    }

}());