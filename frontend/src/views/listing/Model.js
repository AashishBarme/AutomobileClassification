import Config from '../../config/Config';

export default class Model
{
    constructor(data)
    {
        this.title = data.title;
        this.slug = data.slug;
        this.image =  this.setImagePath(data.image);
        this.category = data.category;
        this.postLikeCount = data.postLikeCount
    }

    setImagePath(imagepath)
    {
        return Config.IMAGE_URL + imagepath;
    }
}