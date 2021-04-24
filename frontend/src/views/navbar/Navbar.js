import Helpers from '../../helpers/Helpers';

export default{
    name: 'Navbar',
    data()
    {
        return{
            helpers : new Helpers()
        }
    },
    methods:{
        Logout()
        {
            localStorage.removeItem('token');
            localStorage.removeItem('user');
            this.$router.push('/');
        }
    }
}