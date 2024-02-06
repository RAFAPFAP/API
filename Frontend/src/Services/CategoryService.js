class CategoryService{
    baseUrl = import.meta.env.VITE_API_URL
    baseController = "Category"

    async GetCategories () {
        let response = null;
        try {
            const response =await fetch(`${this.baseUrl}${this.baseController}/GetAll`)
            const categories = await response.json();
            return categories;
        } catch (error) {
            console.log(error);
            return response;
        }
        
    }

    async AddCategory (data) {
        let options = {
            method: 'POST',
            body: JSON.stringify(data),
            headers:{
              "Content-Type": "application/json",
            }
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/Create`, options)
            const category = await response.json();
            return category;
        }
        catch (error) {
            console.log(error);
            return response;
        }
    }
}

export {CategoryService}