import { Component, OnInit, Input } from '@angular/core'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'
@Component({
  selector: 'app-alerta-modal-ok',
  templateUrl: './alerta-modal-ok.component.html',
  styleUrls: ['./alerta-modal-ok.component.css'],
})
export class AlertaModalOkComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {}
  @Input() titulo
  @Input() mensaje
  ngOnInit(): void {}
}


