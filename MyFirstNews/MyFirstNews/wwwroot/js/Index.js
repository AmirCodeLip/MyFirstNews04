(function () {
    window.onpopstate = function () {
        GetNewsAjax(parsUrl(location.href.split("?")));
    };
    function parsUrl(fullUrl) {
        let data = {};
        if (fullUrl.length > 1) {
            let urlQuery = fullUrl[1].split("&");
            for (let i of urlQuery) {
                let caseOf = i.split("=");
                if (caseOf[0] === "RequestTags") {
                    caseOf[0] = "tags";
                }
                data[caseOf[0]] = caseOf[1];
            }
        }
        return data;
    }
    var bodyScop = undefined;
    function SetNewUrl(data) {
        let newUrl = "/Home/Index";

        if (data) {
            newUrl += "?";
            if (data.tags) {
                if (data.tags.length != 0)
                    newUrl += "RequestTags=" + data.tags.toString();
            }
            if (newUrl.length === 1) {
                newUrl = "";
            }

        }




        history.pushState({}, "SetNewUrl", newUrl)
    }


    async function GetNewsAjax(urlData = undefined) {
        let formData = new FormData();
        if (urlData) {
            if (urlData.tags)
                formData.append("tags", urlData.tags.toString());
        }
        let data = await fetch("/Home/GetNews", {
            method: "POST",
            body: formData
        });
        let jsonData = await data.json();

        bodyScop.$apply(function () {

            bodyScop.newses = jsonData;
        });
    }
    this.onNgReady = function ($scop) {
        $scop.newses = [];
        $scop.tags = {};


        $scop.addTag = function (id) {
            $scop.tags[id] = {
                id: id
            }
        };
        $scop.tagChanged = () => {
            let importedTags = [];
            for (let i in $scop.tags) {
                if ($scop.tags[i].isChecked) {
                    importedTags.push($scop.tags[i].id);
                }
            }
            let newUrl = {
                tags: importedTags
            };
            SetNewUrl(newUrl);


            GetNewsAjax(newUrl);

        };

        bodyScop = angular.element(document.body).scope();


        angular.element(document.body).ready(function () {
            let preUrl = parsUrl(location.href.split("?"));
            GetNewsAjax(preUrl);
            if (preUrl.tags)
                for (let i in $scop.tags) {

                    if (preUrl.tags.includes($scop.tags[i].id)) {
                        $scop.tags[i].isChecked = true;
                    }
                }
        });


    }


}());
