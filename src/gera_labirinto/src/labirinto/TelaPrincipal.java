package labirinto;

import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.awt.dnd.DnDConstants;
import java.awt.dnd.DropTarget;
import java.awt.dnd.DropTargetDragEvent;
import java.awt.dnd.DropTargetDropEvent;
import java.awt.dnd.DropTargetEvent;
import java.awt.dnd.DropTargetListener;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;
import org.odftoolkit.odfdom.doc.OdfSpreadsheetDocument;
import org.odftoolkit.odfdom.doc.table.OdfTable;

public class TelaPrincipal extends javax.swing.JFrame implements DropTargetListener {

    public TelaPrincipal() {
        initComponents();
        new DropTarget(this.jtfArquivo, this); 
    }
    
    private void gerarCodigo() {
        try {
            String planilha = jtfArquivo.getText();
            OdfSpreadsheetDocument document = OdfSpreadsheetDocument.loadDocument(
                planilha
            );   
            OdfTable table = document.getTableList().get(0);
            StringBuilder stb = new StringBuilder();
            for (int n = 2; n <= 26; n++) {
                for (int c = 66; c <= 90; c++) {
                    char letra = (char)c;                
                    String address = letra + String.valueOf(n);
                    org.odftoolkit.odfdom.type.Color cor = table.getCellByPosition(
                    address).getCellBackgroundColor();
                    if (cor.getAWTColor().equals(java.awt.Color.BLACK)) {
                        stb.append("1");
                    } else {
                        stb.append("0");
                    }
                }
            }
            jtaCodigo.setText(stb.toString());
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, ex);
        }
    }
    
    /*Método que é ativado quando um arquivo é solto no campo "REL. PA3028:"*/
    @Override
    public void drop(DropTargetDropEvent dtde) {
        try {
            Transferable tr = dtde.getTransferable();             
            dtde.acceptDrop(DnDConstants.ACTION_COPY_OR_MOVE);
            List list = (List) tr.getTransferData(DataFlavor.javaFileListFlavor);
            if (list.size() > 0) {
                List<String> files = new ArrayList<>(list.size());
                for (Object obj : list) {
                    File file = (File)obj;
                    if (!file.isDirectory()) {
                        files.add(file.getAbsolutePath());
                    }
                }
                String file = files.get(0);
                jtfArquivo.setText(file);
            }                
            dtde.dropComplete(true);
        } catch (UnsupportedFlavorException | IOException e) {
            dtde.rejectDrop();
        }
    }  
    
    @Override
    public void dragEnter(DropTargetDragEvent dtde) {}
    @Override
    public void dragOver(DropTargetDragEvent dtde) {}
    @Override
    public void dropActionChanged(DropTargetDragEvent dtde){}
    @Override
    public void dragExit(DropTargetEvent dte) {}

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jtfArquivo = new javax.swing.JTextField();
        jScrollPane1 = new javax.swing.JScrollPane();
        jtaCodigo = new javax.swing.JTextArea();
        jbGerar = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setResizable(false);

        jtfArquivo.setText("Arraste e solte o arquivo aqui");

        jScrollPane1.setVerticalScrollBarPolicy(javax.swing.ScrollPaneConstants.VERTICAL_SCROLLBAR_NEVER);

        jtaCodigo.setColumns(20);
        jtaCodigo.setLineWrap(true);
        jtaCodigo.setRows(5);
        jtaCodigo.setToolTipText("");
        jScrollPane1.setViewportView(jtaCodigo);

        jbGerar.setText("Gerar");
        jbGerar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jbGerarActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jScrollPane1)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jtfArquivo, javax.swing.GroupLayout.DEFAULT_SIZE, 534, Short.MAX_VALUE)
                .addGap(0, 0, 0)
                .addComponent(jbGerar))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jtfArquivo, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jbGerar, javax.swing.GroupLayout.PREFERRED_SIZE, 23, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(0, 0, 0)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 503, Short.MAX_VALUE))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jbGerarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jbGerarActionPerformed
        gerarCodigo();
    }//GEN-LAST:event_jbGerarActionPerformed

    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new TelaPrincipal().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JButton jbGerar;
    private javax.swing.JTextArea jtaCodigo;
    private javax.swing.JTextField jtfArquivo;
    // End of variables declaration//GEN-END:variables
}
