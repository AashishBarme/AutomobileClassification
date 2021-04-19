const Config = {
    ApiBaseUrl: 'http://localhost:5000/api/'
};

const ApiEndPoints = {
    default: Config.ApiBaseUrl ,
    categoryList: Config.ApiBaseUrl + 'categories/list'
};
export { Config, ApiEndPoints};