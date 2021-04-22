import Vue from 'vue';
export default class Helpers
{
    CheckIfUserIsLoggedIn()
    {
        var token = localStorage.getItem("token");
        if(token !== null)
        {
            return true;
        }
        return false;
    }

    DisplayErrorMessageIfNotLoggedIn()
    {
        return Vue.swal({
            icon: 'error',
            title: 'Oops...',
            text: 'You must log in first'
        });
    }
}