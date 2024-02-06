class PostService{
    baseUrl = import.meta.env.VITE_API_URL
    baseController = "Post"

    async GetPosts () {
        let options = {
            method: 'GET',
            headers:{
              "Content-Type": "application/json",
            },
            credentials: 'include',
          };

        let response = null;
        try {
            const response =await fetch(`${this.baseUrl}${this.baseController}/GetAll`, options)
            if(response.status !== 200){
              localStorage.removeItem("loggedIn");
            }
            const posts = await response.json();
            return posts;
        } catch (error) {
            console.log(error);
            return response;
        }
        
    }

    async GetPostsForViewer () {
        let options = {
            method: 'GET',
            headers:{
              "Content-Type": "application/json",
            }
          };

        let response = null;
        try {
            const response =await fetch(`${this.baseUrl}${this.baseController}/GetForViewer`, options)
            const posts = await response.json();
            return posts;
        } catch (error) {
            console.log(error);
            return response;
        }
        
    }

    async AddPost (data) {
        let options = {
            method: 'POST',
            body: JSON.stringify(data),
            headers:{
              "Content-Type": "application/json",
            },
            credentials: "include"
          };

        let response = null;
        try {
            const response = await fetch(`${this.baseUrl}${this.baseController}/Create`, options)
            if(response.status !== 200){
              localStorage.removeItem("loggedIn");
            }
            const post = await response.json();
            return post;
        }
        catch (error) {
            console.log(error);
            return response;
        }
    }
}

export {PostService}