import { registerLocaleData } from '@angular/common';
import { Component } from '@angular/core';
import { Announcement } from './announcement';
import { Category } from './category';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  selectedCategory: string = '';

  readonly announcements: Announcement[] = [
    {
      id: '1',
      message: 'Nu se tine',
      title: 'Curs',
      author: 'Nico',
      category: Category.Course,
      imageUrl: 'img1',
    },
    {
      id: '2',
      message: 'Iesim in Times',
      title: 'Party',
      author: 'Andreea',
      category: Category.General,
      imageUrl: 'img2',
    },
    {
      id: '3',
      message: 'Nu se tine laboratorul de BRTA',
      title: 'Laborator',
      author: 'Maria',
      category: Category.Laboratory,
      imageUrl: 'img3',
    },
  ];

  filtredAnnouncement: Announcement[] = this.announcements;

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
