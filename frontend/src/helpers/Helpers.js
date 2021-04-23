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
            title: 'Hey there!',
            text: 'You forget to log in. You must log in first to post or like in this post',
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: `Login`,
            denyButtonText: `Register`,
            }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = `/login`
            } else if (result.isDenied) {
                window.location.href = `/register`
            }

        });
    }
}