export default class UpdateUserModel
{
    constructor(data)
    {
        this.id = data.id,
        this.userName = data.userName,
        this.firstName = data.firstName,
        this.lastName = data.lastName,
        this.email = data.email
    }
}