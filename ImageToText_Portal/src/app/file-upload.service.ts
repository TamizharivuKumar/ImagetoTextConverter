import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class FileUploadService {
  private uploadUrl = 'https://localhost:44316/api/FileUpload/upload';

  constructor(private http: HttpClient) {}

  uploadFile(file: File) {
    const formData = new FormData();
    formData.append('imageFile', file, file.name);

    return this.http.post<any>(this.uploadUrl, formData);
  }
}
