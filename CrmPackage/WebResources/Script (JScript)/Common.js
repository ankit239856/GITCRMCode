
if (typeof (Ams) == "undefined") {
    Ams = {};
}

if (typeof (Ams.Crm) == "undefined") {
    Ams.Crm = {};
}
if (typeof (Ams.Crm.Common) == "undefined") {
    Ams.Crm.Common = {};
}

Ams.Crm.Common = {

    lockFeild: function (fieldName, disabled, formContext)
    {
        var fieldControl = formContext.getControl(fieldName);
        if (fieldControl != null)
        {
            fieldControl.setDisabled(disabled);
        }

    }

}