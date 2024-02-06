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
import { useEffect } from 'react';
import { AuthService } from '../Services/AuthService';

function User(){
    const [open, setOpen] = React.useState(false);
    const [openDelete, setOpenDelete] = React.useState(false);
    const [nombre, setNombre] = React.useState("");
    const [users, setUsers] = React.useState([])

    useEffect(() => {
      refreshList();
    }, []);

    const refreshList = async () =>{
      let service = new AuthService();
      let usersResponse = await service.GetAllUsers();
      setUsers(usersResponse.data)
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

      const handleAddUser = () => {
        
        let data = {
          "nombre":nombre
        };

        let service = new UserService();
        service.AddUser(data).then(x => {
          refreshList();
          setOpen(false)
        })

      };

      const handleDeleteUser = () => {
        alert("Eliminado: " + nombre)
      };

    return(

        <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={2}>
          <Grid item xs={12} textAlign={'center'}>
              <h1>User Component</h1>
          </Grid>
          <Grid item xs={12}>
            <Grid item lg={3}>
                <Button variant="contained" color="success" onClick={handleClickOpen}>
                    Agregar Usuario
                </Button>
            </Grid>
          </Grid>
          <Grid item xs={12}>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                    <TableRow>
                        <TableCell>Id</TableCell>
                        <TableCell>Username</TableCell>
                        <TableCell>Email</TableCell>
                        <TableCell>Acciones</TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {users.map(user => {
                                        return(
                                            <TableRow
                                                key={user.id}
                                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                            >
                                                <TableCell component="th" scope="row">
                                                    {user.id}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {user.name}
                                                </TableCell>
                                                <TableCell component="th" scope="row">
                                                    {user.email}
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
                  "Agregar nueva Usuario"
                </DialogTitle>
                <DialogContent>
                  <DialogContentText id="alert-dialog-description">
                  <Grid container spacing={2}>
                      <Grid item xs={12}>
                        <TextField placeholder='Nombre' value={nombre} onChange={handleChangeNombre}/>
                      </Grid>
                  </Grid>
                  </DialogContentText>
                </DialogContent>
                <DialogActions>
                  <Button onClick={handleClose}>Cerrar</Button>
                  <Button onClick={handleAddUser} autoFocus>
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
                {"Eliminar Usuario"}
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
                <Button onClick={handleDeleteUser} autoFocus>
                    Eliminar
                </Button>
                </DialogActions>
            </Dialog>
      </Box>
    );
}

export {User};