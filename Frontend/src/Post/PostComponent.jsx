import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import UpdateIcon from '@mui/icons-material/Update';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import IconButton from '@mui/material/IconButton';
import Grid from '@mui/material/Grid';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import { useEffect } from 'react';
import { PostService } from '../Services/PostService';
import { CategoryService } from '../Services/CategoryService';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';

function Post(){
    const [open, setOpen] = React.useState(false);
    const [openDelete, setOpenDelete] = React.useState(false);
    const [nombre, setNombre] = React.useState("");
    const [resumen, setResumen] = React.useState("");
    const [descripcion, setDescripcion] = React.useState("");
    const [imageUrl, setImageUrl] = React.useState("");
    const [prioridad, setPrioridad] = React.useState(0);
    const [fechaPublicacion, setFechaPublicacion] = React.useState(dayjs());
    const [categories, setCategories] = React.useState([]);
    const [categoryIds, setCategoryIds] = React.useState([]);
    const [posts, setPosts] = React.useState([])

    const ITEM_HEIGHT = 25;
    const ITEM_PADDING_TOP = 5;
    const MenuProps = {
    PaperProps: {
        style: {
        maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
        width: 250,
        },
    },
    };

    useEffect(() => {
      refreshList();
      fillCategories();
    }, []);

    const refreshList = async () =>{
      let service = new PostService();
      let posts = await service.GetPosts();
      if (posts !== null) {
        setPosts(posts)
      }else{
        setPosts([])
      }
      
    }

    const fillCategories = async () =>{
        let service = new CategoryService();
        let categories = await service.GetCategories();
        setCategories(categories)
      }

    const handleClickOpen = () => {
        setOpen(true);
      };

      const handleClickOpenDelete = () => {
        setOpenDelete(true);
      };
    
      const handleClose = () => {
        setOpen(false);
      };

      const handleCloseDelete = () => {
        setOpenDelete(false);
      };

      const handleChangeNombre = (e) =>
      {
        setNombre(e.target.value)
      }

      const handleChangeResumen = (e) =>
      {
        setResumen(e.target.value)
      }

      const handleChangeDescripcion = (e) =>
      {
        setDescripcion(e.target.value)
      }

      const handleChangeImageUrl = (e) =>
      {
        setImageUrl(e.target.value)
      }

      const handleChangePrioridad = (e) =>
      {
        setPrioridad(e.target.value)
      }

      const handleChangeCategories = (event) =>
      {
        console.log(event.target.value);
        const {
            target: { value },
          } = event;
          setCategoryIds(
            // On autofill we get a stringified value.
            typeof value === 'string' ? value.split(',') : value,
          );
      }

      const handleAddPost = () => {
        
        let data = {
          "nombre":nombre,
          "resumen": resumen,
          "descripcion" : descripcion,
          "imageUrl" : imageUrl,
          "prioridad" : prioridad,
          "fechaDePublicacion" : fechaPublicacion,
          "categoryIds":categoryIds
        };

        let service = new PostService();
        service.AddPost(data).then(x => {
          refreshList();
          setOpen(false)
        })

      };

      const handleDeletePost = () => {
        alert("Eliminado: " + nombre)
      };

    return(

        <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={2}>
          <Grid item xs={12} textAlign={'center'}>
              <h1>Post Component</h1>
          </Grid>
          <Grid item xs={12}>
            <Grid item lg={3}>
                <Button variant="contained" color="success" onClick={handleClickOpen}>
                    Agregar Post
                </Button>
            </Grid>
          </Grid>
          <Grid item xs={12}>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                    <TableRow>
                        <TableCell>Id</TableCell>
                        <TableCell>Nombre</TableCell>
                        <TableCell>Resumen</TableCell>
                        <TableCell>Descripcion</TableCell>
                        <TableCell>Imagen</TableCell>
                        <TableCell>Prioridad</TableCell>
                        <TableCell>Fecha Publicacion</TableCell>
                        <TableCell>Categorias</TableCell>
                        <TableCell>Acciones</TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {posts.map(post => {
                                        return(
                                            <TableRow
                                                key={post.id}
                                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                            >
                                                <TableCell component="th" scope="row">
                                                    {post.id}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.nombre}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.resumen}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.descripcion}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.imageUrl}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.prioridad}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.fechaDePublicacion}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {post.categories}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    <IconButton color="primary" aria-label="edit" component="label" onClick={() => handleUpdateClick(expense.id)}>
                                                        <UpdateIcon />
                                                    </IconButton>
                                                    <IconButton color="primary" aria-label="edit" component="label" onClick={() => handleDeleteClick(expense.id)}>
                                                        <DeleteForeverIcon />
                                                    </IconButton>
                                                </TableCell>
                                            </TableRow>
                                        )
                                    })}
                        
                    </TableBody>
                </Table>
                </TableContainer>
          </Grid>
        </Grid>

        <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">
                  Agregar nuevo post
                </DialogTitle>
                <DialogContent>
                  <DialogContentText id="alert-dialog-description">
                  <Grid container spacing={2}>
                      <Grid item xs={12}>
                        <TextField placeholder='Nombre' value={nombre} onChange={handleChangeNombre}/>
                      </Grid>
                      <Grid item xs={12}>
                        <TextField placeholder='Resumen' value={resumen} onChange={handleChangeResumen}/>
                      </Grid>
                      <Grid item xs={12}>
                        <TextField placeholder='Descripcion' value={descripcion} onChange={handleChangeDescripcion}/>
                      </Grid>
                      <Grid item xs={12}>
                        <TextField placeholder='Image URL' value={imageUrl} onChange={handleChangeImageUrl}/>
                      </Grid>
                      <Grid item xs={12}>
                        <TextField type='number' placeholder='Prioridad' value={prioridad} onChange={handleChangePrioridad}/>
                      </Grid>
                      <Grid item xs={12}>
                        <LocalizationProvider dateAdapter={AdapterDayjs}>
                            <DemoContainer components={['DatePicker', 'DatePicker']}>
                                <DatePicker
                                label="Fecha Publicacion"
                                value={fechaPublicacion}
                                onChange={(newValue) => setFechaPublicacion(newValue)}
                                />
                            </DemoContainer>
                        </LocalizationProvider>
                      </Grid>
                      <Grid>
                        <FormControl sx={{ m: 1, width: 300 }}>
                            <InputLabel id="categories">Categories</InputLabel>
                            <Select
                            labelId="categories"
                            id="categories"
                            multiple
                            value={categoryIds}
                            onChange={handleChangeCategories}
                            input={<OutlinedInput label="Categories" />}
                            MenuProps={MenuProps}
                            >
                            {categories.map((category) => (
                                <MenuItem
                                key={category.id}
                                value={category.id}
                                >
                                {category.nombre}
                                </MenuItem>
                            ))}
                            </Select>
                        </FormControl>
                      </Grid>
                  </Grid>
                  </DialogContentText>
                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose}>Cerrar</Button>
                  <Button onClick={handleAddPost} autoFocus>
                      Agregar
                  </Button>
                </DialogActions>
            </Dialog>

            <Dialog
                open={openDelete}
                onClose={handleCloseDelete}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">
                {"Eliminar post"}
                </DialogTitle>
                <DialogContent>
                <DialogContentText id="alert-dialog-description">
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        Esta seguro de eliminar este registro?
                    </Grid>
                </Grid>
                </DialogContentText>
                </DialogContent>
                <DialogActions>
                <Button onClick={handleCloseDelete}>Cerrar</Button>
                <Button onClick={handleDeletePost} autoFocus>
                    Eliminar
                </Button>
                </DialogActions>
            </Dialog>
      </Box>
    );
}

export default Post;