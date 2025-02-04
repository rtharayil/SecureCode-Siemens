class Server {

   // ... SERVER CODE

   /* Vulnerable code */
   public FileContentResult RetrieveImage(string img_path) {
       bytes[] img = System.IO.File.ReadAllBytes(img_path);

       if (img == null) {
           return null;
       }

       return File(img, "image/jpg");
   }

   // ... SERVER CODE
}