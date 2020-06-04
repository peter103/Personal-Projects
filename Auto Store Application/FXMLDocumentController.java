/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package websiteprototype;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import com.jfoenix.controls.JFXButton;
import java.io.IOException;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;


/**
 *
 * @author peter
 */
public class FXMLDocumentController 
{

    @FXML
    private Label label;
    
    
    @FXML
    private JFXButton partsClick;
    private JFXButton rover6Click;

    @FXML
            
    void parts(ActionEvent event) throws Exception
    {
     
        Node source = (Node) event.getSource();
        String id = source.getId();
        
        
        if(id.equals("AutoServices"))
        {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("services.fxml"));
            Parent root = loader.load();

            Scene tableViewScene = new Scene(root);

            Stage window = new Stage();
            window.setScene(tableViewScene);
            window.show();
        }
        
        if(id.equals("rover6Click"))
        {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("Rover6.fxml"));
            Parent root = loader.load();

            Scene tableViewScene = new Scene(root);

            Stage window = new Stage();
            window.setScene(tableViewScene);
            window.show();
        }
        if(id.equals("partsClick"))
        {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("website_2.fxml"));
            Parent root = loader.load();

            Scene tableViewScene = new Scene(root);

            Stage window = new Stage();
            window.setScene(tableViewScene);
            window.show();
        }
        if(id.equals("TurboKit"))
        {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("TurboKit.fxml"));
            Parent root = loader.load();

            Scene tableViewScene = new Scene(root);

            Stage window = new Stage();
            window.setScene(tableViewScene);
            window.show();
        }
  
    }
    


}

