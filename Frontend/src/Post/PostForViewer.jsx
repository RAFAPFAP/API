import * as React from 'react';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import { useEffect } from 'react';
import { PostService } from '../Services/PostService';


function PostForViewer(){
    const [posts, setPosts] = React.useState([]);
    useEffect(() => {
      refreshList();
    }, []);

    const refreshList = async () =>{
      let service = new PostService();
      let posts = await service.GetPostsForViewer();
      if (posts !== null) {
        setPosts(posts)
      }else{
        setPosts([])
      }
      
    }

    
    return(

        <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={2}>
            <Grid item xs={12} textAlign={'center'}>
                <h1>Posts</h1>
            </Grid>
            {posts.map(post => {
                                return(
                                    <>
                                    <Grid item xs={12} textAlign={'center'}>
                                        <h1>{post.nombre}</h1>
                                    </Grid>
                                    <Grid item xs={12} textAlign={'center'}>
                                        <img src={post.imageUrl} width={"25%"} />
                                    </Grid>
                                    <Grid item xs={12} textAlign={'center'}>
                                        <p>{post.descripcion}</p>
                                    </Grid>
                                    <Grid item xs={12} textAlign={'center'}>
                                        <p>{post.fechaDePublicacion}</p>
                                    </Grid>
                                    <hr/>
                                    </>
                                    
                                    
                                )
                            })}
          
        </Grid>

        
      </Box>
    );
}

export {PostForViewer};