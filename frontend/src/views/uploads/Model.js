export default class Model 
{
    constructor(data)
    {
        this.title = data.title;
        this.url = data.url;
        this.categoryId = data.categoryId;
        this.userId = data.userId;
        this.imageName = data.imageName;
    }
}