import { Component } from '@angular/core';
import { FileUploadService } from '../file-upload.service';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css'],
})
export class ImageUploadComponent {
  selectedFile: File | null = null;
  text: string | null = null;
  imageSrc: string = '';
  isPreview: boolean = false;
  isSuccess: boolean = false;
  isError: boolean = false;

  constructor(private fileUploadService: FileUploadService) {}
  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      if (
        file.type === 'image/png' ||
        file.type === 'image/jpeg' ||
        file.type === 'image/jpg'
      ) {
        this.selectedFile = file;
        const reader = new FileReader();
        this.isError = false;
        this.isPreview = true;
        this.isSuccess = false;
        reader.onload = (e) => {
          this.imageSrc = reader.result as string;
        };
        reader.readAsDataURL(this.selectedFile);
      } else {
        this.isError = true;
        this.isPreview = false;
        this.isSuccess = false;
        this.selectedFile = null;
        this.text = null;
      }
    }
  }

  onUpload() {
    if (this.selectedFile) {
      this.fileUploadService.uploadFile(this.selectedFile).subscribe(
        (response) => {
          this.text = response.message;
          this.isSuccess = true;
        },
        (error) => {
          console.error('Error uploading file: ', error);
          // Handle error here if needed
        }
      );
    }
  }
}
