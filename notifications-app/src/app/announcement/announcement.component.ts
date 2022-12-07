import { Component, Input, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.scss'],
})
export class AnnouncementComponent implements OnInit {
  @Input('announc') announcement: Announcement;

  constructor(private service: AnnouncementService) {}

  ngOnInit(): void {}

  deleteAnnouncement() {
    this.service.deleteAnnouncement(this.announcement.id).subscribe();
  }
}
