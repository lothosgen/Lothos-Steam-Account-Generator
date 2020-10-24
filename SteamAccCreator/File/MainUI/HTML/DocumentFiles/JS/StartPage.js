function buttonHandler_generate(id) {
    if (document.getElementById(id).getAttribute('name') === 'false') {
        document.getElementById(id).setAttribute('name', 'true');
    }
}
function chkbuttonClick(id) {
    if (document.getElementById(id).getAttribute('name') === 'false') {
        document.getElementById(id).style.background = '#5ec147';
        document.getElementById(id).setAttribute('name', 'true');
    }
    else {
        document.getElementById(id).style.background = '#2F2F2F';
        document.getElementById(id).setAttribute('name', 'false');
    }
}
function buttonHandler_settings() {
    if (document.getElementById('btn_settings').getAttribute('name') === 'false') {
        document.getElementById('btn_settings').setAttribute('name', 'true');
    }
}
function buttonHandler_dashboard() {
    if (document.getElementById('btn_dashboard').getAttribute('name') === 'false') {
        document.getElementById('btn_dashboard').setAttribute('name', 'true');
    }
}
function buttonHandler_history() {
    if (document.getElementById('btn_history').getAttribute('name') === 'false') {
        document.getElementById('btn_history').setAttribute('name', 'true');
    }
}
function buttonHandler_proxy() {
    if (document.getElementById('btn_proxy').getAttribute('name') === 'false') {
        document.getElementById('btn_proxy').setAttribute('name', 'true');
    }
}
function PageEnablerChange(id) {
    var HomeID = 'HomeEnabled';
    var HistoryID = 'HistoryEnabled';
    var ProxyID = 'ProxyEnabled';
    var SettingsID = 'SettingsEnabled';
    var UpdatesID = 'UpdatesEnabled';

    var HomeIDValue = document.getElementById(HomeID).getAttribute('value').toString();
    var HistoryIDValue = document.getElementById(HistoryID).getAttribute('value').toString();
    var ProxyIDValue = document.getElementById(ProxyID).getAttribute('value').toString();
    var SettingsIDValue = document.getElementById(SettingsID).getAttribute('value').toString();
    var UpdatesIDValue = document.getElementById(UpdatesID).getAttribute('value').toString();

    if (document.getElementById(id).getAttribute('value') === 'true') {
        document.getElementById(id).getAttribute('value') = 'true';
    }

    if (document.getElementById(id).getAttribute('value') === 'false') {
        document.getElementById(id).style.background = '#42f459';
        document.getElementById(id).setAttribute('value', 'true');
    }
    else {
        document.getElementById(id).style.background = '#808080';
        document.getElementById(id).setAttribute('value', 'false');
    }
    if (HomeIDValue === 'true' && id !== HomeID) {
        document.getElementById(HomeID).setAttribute('value', 'false');
        document.getElementById(HomeID).style.background = '#808080';
    }
    if (HistoryIDValue === 'true' && id !== HistoryID) {
        document.getElementById(HistoryID).setAttribute('value', 'false');
        document.getElementById(HistoryID).style.background = '#808080';
    }
    if (ProxyIDValue === 'true' && id !== ProxyID) {
        document.getElementById(ProxyID).setAttribute('value', 'false');
        document.getElementById(ProxyID).style.background = '#808080';
    }
    if (SettingsIDValue === 'true' && id !== SettingsID) {
        document.getElementById(SettingsID).setAttribute('value', 'false');
        document.getElementById(SettingsID).style.background = '#808080';
    }
    if (UpdatesIDValue === 'true' && id !== UpdatesID) {
        document.getElementById(UpdatesID).setAttribute('value', 'false');
        document.getElementById(UpdatesID).style.background = '#808080';
    }
}
function buttonHandler_OptionSettings() {
    if (document.getElementById('btn_optionSettings').getAttribute('name') === 'false') {
        document.getElementById('btn_optionSettings').setAttribute('name', 'true');
    }
}
function buttonHandler_updates() {
    if (document.getElementById('btn_updates').getAttribute('name') === 'false') {
        document.getElementById('btn_updates').setAttribute('name', 'true');
    }
}