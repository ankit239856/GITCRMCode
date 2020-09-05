///<reference path="./common.js" />

if (typeof (Ams) == "undefined") {
    Ams = {};
}

if (typeof (Ams.Crm) == "undefined") {
    Ams.Crm = {};
}

if (typeof (Ams.Crm.CrmPackage) == "undefined") {
    Ams.Crm.CrmPackage = {};
}

Ams.Crm.CrmPackage = {
 
    productCount: 0,
    alarmStatus: false,
    usersPosition: "",
    floatValue: 0.00,
    PageLoad: {
        instructionSentRequired: null,
        LetterReceived : false
    },

    User_Messages: {

        Letter_Generating: "Letter is getting generated please wait for process to complete",
        LetterGenerated: "Letter generated successfully"

    },

    ContactNumberUpdated: function (executionContext) {
        debugger;
        var formContext = executionContext.getFormContext();

        var contactId = formContext.getAttribute("primarycontactid").getValue();
        var accountNumber = formContext.getAttribute("ams_accountnumber").getValue();
        if (accountNumber != null)
        {
            Ams.Crm.Common.lockFeild("ams_accountnumber",true,formContext);
        }
            



    }





}

