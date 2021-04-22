export default class CommentModel
{
    constructor(data)
    {
        this.postId = data.postId,
        this.comment  = data.message,
        this.userId = data.userId
    }
}