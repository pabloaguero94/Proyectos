/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controlador;

import Modelo.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 *
 * @author alumno
 */
public class ControladorBD {
    
    private Connection con;
    
    private void abrirConexion()
    {
        try 
        {
            con = DriverManager.getConnection("jdbc:sqlserver://172.16.140.13;databaseName=FinalProg3primer","alumno1w1","alumno1w1");
        } 
        catch (SQLException ex) { }
    }
    
    private void cerrarConexion()
    {
        try 
        {
            if(con != null && !con.isClosed())
                con.close();
        } 
        catch (SQLException ex) { }
    }
    
    public ArrayList<Producto> obtenerProductos()
    {
        ArrayList<Producto> lista = new ArrayList<Producto>();
        try 
        {
                abrirConexion();
                Statement st = con.createStatement(); //Como el Command de .net
                ResultSet rs = st.executeQuery("select * from productos"); // Como el DataReader de .net

                while(rs.next()) {
                    int id = rs.getInt("id");
                    String nombre = rs.getString("nombre");
                    float precio = rs.getFloat("precio");
                    lista.add(new Producto(id, nombre, precio));
                }
                rs.close();
        } 
        catch (SQLException ex) { }
        finally {
            cerrarConexion();
        }
        return lista;
    }
    
    public ArrayList<Venta> obtenerVentas()
    {
        ArrayList<Venta> lista = new ArrayList<Venta>();
        try 
        {
                abrirConexion();
                Statement st = con.createStatement(); //Como el Command de .net
                ResultSet rs = st.executeQuery("select v.*, p.nombre as producto, p.id as idProducto from ventas v inner join productos p on v.productoId = p.id"); // Como el DataReader de .net

                while(rs.next()) {
                    int id = rs.getInt("id");
                    String fecha = rs.getString("fecha");
                    int cantidad = rs.getInt("cantidad");
                    int descuento = rs.getInt("descuento");
                    
                    String nombreProducto = rs.getString("producto");
                    int idProducto = rs.getInt("idProducto");
                    Producto p = new Producto();
                    p.setId(idProducto);
                    p.setNombre(nombreProducto);
                    
                    Venta venta = new Venta(fecha, cantidad, descuento, p);
                    venta.setId(id);
                    lista.add(venta);
                }
                rs.close();
        } 
        catch (SQLException ex) { }
        finally {
            cerrarConexion();
        }
        return lista;
    }
    
    public boolean insertarVenta(Venta venta)
    {
        boolean inserto = false;
        try 
        {
                abrirConexion();
                String sql = "INSERT INTO Ventas (fecha, descuento, cantidad, productoId) VALUES (?,?,?,?)";
                PreparedStatement st = con.prepareStatement(sql); 
                st.setString(1, venta.getFecha());
                st.setInt(2, venta.getDescuento());
                st.setInt(3, venta.getCantidad());
                st.setInt(4, venta.getProducto().getId());
                st.execute(); // Como el ExecuteNonQuery de .net
                inserto = true;
        } 
        catch (SQLException ex) { }
        finally {
            cerrarConexion();
        }
    
        return inserto;
    }
    
    public boolean actualizarVenta(Venta venta)
    {
        boolean actualizo = false;
        try 
        {
                abrirConexion();
                String sql = "UPDATE Ventas SET fecha = ?, descuento = ?, cantidad = ?, productoId = ? WHERE id = ?";
                PreparedStatement st = con.prepareStatement(sql); 
                st.setString(1, venta.getFecha());
                st.setInt(2, venta.getDescuento());
                st.setInt(3, venta.getCantidad());
                st.setInt(4, venta.getProducto().getId());
                st.setInt(5, venta.getId());
                st.execute(); 
                actualizo = true;
        } 
        catch (SQLException ex) { }
        finally {
            cerrarConexion();
        }
    
        return actualizo;
    }
    
    public boolean eliminarVenta(int id)
    {
        boolean elimino = false;
        try 
        {
                abrirConexion();
                String sql = "DELETE Ventas WHERE id = ?";
                PreparedStatement st = con.prepareStatement(sql); 
                st.setInt(1, id);
                st.execute(); 
                elimino = true;
        } 
        catch (SQLException ex) { }
        finally {
            cerrarConexion();
        }
    
        return elimino;
    }
}
