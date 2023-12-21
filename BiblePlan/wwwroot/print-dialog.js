window.openPrintDialog = function (content, fileName) {
    try {
        var decodedContent = atob(decodeURIComponent(content.split(',')[1]));
        var printWindow = window.open('', '_blank');
        printWindow.document.write('<html><style> body { font-family:\'Roboto\',sans-serif; max-width:90%; display:block; margin:auto \} .container { display:flex; flex-wrap:wrap; \} .pair { flex-basis:28%; margin:0 0.85rem; }</style><title>' + fileName + '</title></head><body>');
        printWindow.document.write('<pre>' + decodedContent + '</pre>');
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    } catch (error) {
        console.log(error);
    }
};