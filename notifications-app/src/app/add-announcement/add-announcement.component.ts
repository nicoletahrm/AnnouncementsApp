import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-add-announcement',
  templateUrl: './add-announcement.component.html',
  styleUrls: ['./add-announcement.component.scss'],
})
export class AddAnnouncementComponent implements OnInit {
  newAnnouncement: Announcement;
  title: string = '';
  message: string = '';
  author: string = '';
  imageUrl: string = '';
  categories: string[] = Object.keys(Category);
  selectedCategory: string = '';

  constructor(private service: AnnouncementService) {}

  ngOnInit(): void {}

  addAnnouncement() {
    this.newAnnouncement = {
      id: this.service.getAnnouncements.length.toString() + 1,
      title: this.title,
      message: this.message,
      author: this.author,
      imageUrl: this.imageUrl,
      category: this.selectedCategory as Category,
    };

    this.service.postAnnouncement(this.newAnnouncement).subscribe();
  }
}
