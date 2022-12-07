import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private announcementService: AnnouncementService) {}

  announcements: Announcement[] = [];
  filtredAnnouncement: Announcement[];

  ngOnInit(): void {
    this.announcementService.serviceCall();

    this.announcementService
      .getAnnouncements()
      .subscribe((result) => (this.announcements = result));

    this.filtredAnnouncement = this.announcements;
  }

  selectedCategory: string = '';

  changeCategory(category: string) {
    this.selectedCategory = category;

    if (category == '') {
      this.filtredAnnouncement = this.announcements;
    } else {
      this.filtredAnnouncement = this.announcements.filter(
        (announcement) => announcement.category === (category as Category)
      );
    }
  }
}
