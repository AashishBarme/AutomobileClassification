import Config from '../../config/Config';

export default class Model 
{
    constructor(data)
    {
        this.id = data.id;
        this.title = data.title;
        this.url = data.url;
        this.image = this.setImagePath(data.image);
        this.category = data.category;
        this.totalLikes = data.totalLikes;
        this.comments = data.comments;
        this.totalComments = data.comments.length;
    }

    setImagePath(imagepath)
    {
        return Config.IMAGE_URL + imagepath;
    }
}