class Server {

   // ... SERVER CODE

   public FileContentResult RetrieveImage(string img_path) {
       // Get the REAL path being requested
       string abs_img_path = Path.GetFullPath(img_path);

       // Whitelist directory files can be retrieved from
       string base_dir = "C:\Applications\Documents";

       if ( !abs_img_path.StartsWith(base_dir) ) {
           // Not an allowed path!
           return null;
       }

       bytes[] img = System.IO.File.ReadAllBytes(abs_img_path);

       if (img == null) {
           return null;
       }

       return File(img, "image/jpg");
   }

   // ... SERVER CODE
}