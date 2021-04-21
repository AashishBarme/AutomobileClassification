export default class AppStorage
{

 // 
   // localStorage.setItem('user','{"Id":1,"Username":"admin","Email":"kpocompany2017@gmail.com","FirstName":"Super","MiddleName":"","LastName":"Group","Identifier":"admin","IsActive":1,"CreatedAt":"2020-05-22 05:42:03","UpdatedAt":"2020-10-05 12:54:27","Projects":null,"UserGroup":"admin","Salary":0,"SalaryType":2,"BonusAmount":"0.00","BonusType":0,"UserProjects":[{"Id":3,"Title":"HZ"},{"Id":2,"Title":"100%"},{"Id":4,"Title":"Ans"}],"Permissions":["CreatePost","UpdatePost","ListPost","DeletePost","PublishPost","ViewUserPosts","CreateTopic","UpdateTopic","DeleteTopic","ListTopic","PullTopic","UpdateUserGroup","ListUserGroup","CreateUser","UpdateUser","DeleteUser","ListUser","CreateFormat","UpdateFormat","DeleteFormat","ListFormat","CreateWebsite","UpdateWebsite","DeleteWebsite","ListWebsite","CreateTopicType","UpdateTopicType","DeleteTopicType","ListTopicType","CreateCategory","UpdateCategory","DeleteCategory","ListCategory","CanViewUserReport"]}');
    setToken(token)
    {
        
        localStorage.setItem('token',token);
    }

    getToken()
    {
        return localStorage.getItem("token");
    }

    setUser(user)
    {   
        localStorage.setItem('user',JSON.stringify(user));
    }

    getUser()
    {
        return JSON.parse(localStorage.getItem("user"));
    }

}