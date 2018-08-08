$(document).ready(function () {
    var dealersDataSource = new kendo.data.DataSource({
        batch: true,
        transport: {
            read: {
                url: "http://localhost:50183/Player/GetDealers",
                dataType: "json"
            },
        },
        schema: {
            model: {
                Id: "Id",
                fields: {
                    Id: { type: "number" },
                    Name: { type: "string" }
                }
            }
        }
    });
    $("#Dealers").kendoDropDownList({
        dataTextField: "Name",
        dataValueField: "Id",
        dataSource: dealersDataSource
    });
    var playerDataSource = new kendo.data.DataSource({
        batch: true,
        transport: {
            read: {
                url: "http://localhost:50183/Player/GetPlayers",
                dataType: "json"
            }
        },
        schema: {
            model: {
                Id: "Id",
                fields: {
                    Id: { type: "number" },
                    Name: { type: "string" }
                }
            }
        }
    });
    $("#players").kendoComboBox({
        filter: "startswith",
        dataTextField: "Name",
        dataValueField: "Id",
        dataSource: playerDataSource,
        noDataTemplate: $("#noDataTemplate").html()
    });
});