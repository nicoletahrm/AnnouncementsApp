import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { NotificationService } from '../services/notification.service';

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

  constructor(
    private announcementService: AnnouncementService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {}

  addAnnouncement() {
    this.newAnnouncement = {
      id: '',
      title: this.title,
      message: this.message,
      author: this.author,
      imageUrl: this.imageUrl,
      category: this.selectedCategory as Category,
    };

    this.announcementService
      .postAnnouncement(this.newAnnouncement)
      .subscribe((r) =>
        this.notificationService.sendMessage('BroadcastMessage', [r])
      );
  }
}
