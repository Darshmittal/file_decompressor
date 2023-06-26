use std::fs;
use std::io;



fn main() {
     
     std:: process::exit(real_main());

     //The main function is the entry point of the program. 
     //It immediately calls the real_main function and exits 
     //the program with the code returned by real_main.
}

fn real_main() -> i32{


    let args: Vec<_> = std::env::args().collect();
    //this line collects the command line arguments into a vector

    if args.len()<2 {
 
        println!("Usage: {} <filename>", args[0]);
        return 1;
    }

    // the above code checks if the command line argumenta are less than 2 it means
    // user does not provide ZIP file name in that case it shows error

    let fname = std::path::Path::new(&*args[1]);
    let file = fs::File::open(&fname).unwrap();

    //in the above code first we create the path object from the second argument passed
    //bu user which is basically the filename.
    //then it opens that file and return the result object
    // the unwrap() methid is used to extarcct tjhe open file or panic it
    //there was an error.

    let mut archive = zip::ZipArchive::new(file).unwrap();


    //the above line create the ziparchieve object from the open file
    

    for i in 0..archive.len()  {

        let mut file = archive.by_index(i).unwrap();

        //for loop iterates over the files in ZipArchive and get to each file
        // the index value and them store the extracted file in the file variable.

        let outpath = match file.enclosed_name()
        {

            Some(path) => path.to_owned(),
            None=> continue,
        };
        // the above code block uses the pattern matching
        //outpath store option type some(path) or noe depends on the file.
        {
            let comment = file.comment();

            if !comment.is_empty(){
                println!("File {} comment: {}",i,comment);
            }
        }

        if(*file.name()).ends_with('/'){

            println!("File {} extracted to \"{}\" ",i,outpath.display());
            fs::create_dir_all(&outpath).unwrap();
        }else{


            println!(

                "File {} extracted to \"{}\"({} bytes)",
                i,
                outpath.display(),
                file.size()
            );

            if let Some(p) = outpath.parent(){

                if !p.exists() {

                    fs::create_dir_all(&p).unwrap();
                }
            }

            let mut outfile = fs::File::create(&outpath).unwrap();
            io::copy(&mut file, &mut outfile).unwrap();
        
        }

        #[cfg(unix)]
        {
            use std::os::unix::fs::PermissionExt;

            if let Some(mode) = file.unix_mode(){

                fs::set_permissions(&outpath, fs::Permissions::from_mode(mode)).unwrap();
            }
        }  

    }

    0

}



    
    











   






