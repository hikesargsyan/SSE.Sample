import {Component, OnDestroy, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {Subscription, SubscriptionLike} from "rxjs";
import {NgIf} from "@angular/common";
import {UrlConstant} from "../../core/constants/url.constant";
import {EventSourceService} from "../../providers/services/event-source.service";

@Component({
  selector: 'app-text-process',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf
  ],
  providers: [EventSourceService],
  templateUrl: './text-process.component.html',
  styleUrl: './text-process.component.scss'
})
export class TextProcessComponent implements OnDestroy {
  textForm: FormGroup;
  outputText: string = '';
  isProcessing: boolean = false;
  private eventSource!: EventSource;
  private eventSourceSubscription!: SubscriptionLike;

  constructor(private fb: FormBuilder, private eventSourceService: EventSourceService) {
    this.textForm = this.fb.group({
      inputText: ['', [Validators.maxLength(100)]],
    });
  }

  get inputTextForm() {
    return this.textForm.get('inputText');
  }

  processText() {
    if (this.textForm.invalid) {
      return;
    }

    const inputText = this.inputTextForm?.value;
    this.isProcessing = true;
    this.outputText = '';

    this.eventSourceSubscription = this.eventSourceService
      .processServerSentEvents(`${UrlConstant.TextProcessingUrl}/${inputText}`)
      .subscribe({
          next: data => {
            this.outputText += data;
          },
          error: error => {
            this.closeTextProcess();
          },
          complete: () => {
            this.closeTextProcess();
          }
        }
      );
  }

  closeTextProcess() {
    if (this.eventSourceSubscription) {
      this.eventSourceSubscription.unsubscribe();
    }
    this.eventSourceService.closeServerSentEvents();
    this.isProcessing = false;
  }

  ngOnDestroy(): void {
    this.closeTextProcess();
  }

}



