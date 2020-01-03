import { Component, OnInit } from '@angular/core';
import { Meme } from '../types/meme';
import { DataService } from '../data/data.service';

@Component({
  selector: 'app-memes',
  templateUrl: './memes.component.html',
  styleUrls: ['./memes.component.less']
})
export class MemesComponent implements OnInit {

  public memes: Meme[] = [];
  public selectedMeme: Meme;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.get('http://localhost:50307/api/Main/GetMemes')
      .subscribe((data) => {
        this.memes = JSON.parse(JSON.stringify(data));
    });
  }

  viewImage(meme: Meme) {
    this.selectedMeme = meme;

    var button = document.getElementById('openModal');
    button.click();
  }

}
