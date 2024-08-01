import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ImageUploadComponent } from './image-upload/image-upload.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [ImageUploadComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [],
  bootstrap: [ImageUploadComponent],
})
export class AppModule {}
