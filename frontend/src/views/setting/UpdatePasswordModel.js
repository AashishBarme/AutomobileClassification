export default class UpdateUserModel{
    constructor(data)
    {
        this.id = JSON.parse(localStorage.getItem("user")).id,
        this.password = data.main
    }
}