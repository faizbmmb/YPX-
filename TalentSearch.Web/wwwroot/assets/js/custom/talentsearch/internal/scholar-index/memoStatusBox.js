document.addEventListener('DOMContentLoaded', function () {
    const MemoId = new URLSearchParams(window.location.search).get('id');
    console.log(MemoId);
    
    $.ajax({
        type: 'post',
        url: 'http://localhost:5101/api/Recovery/Recovery/GetMemoStatus',
        contentType: 'application/json',
        data: JSON.stringify({ _Id: MemoId }),
        success: function (result) {

            console.log(result['Result']['0']['memostatusid']);
            const memostatusid = result['Result']['0']['memostatusid'];
            let reviewedTime = result['Result']['0']['reviewed'];
            let approvedTime = result['Result']['0']['approved'];
            let memoapprovedTime = result['Result']['0']['memo_approved'];
            let issuedTime = result['Result']['0']['issued'];
            const reviewedBy = result['Result']['0']['reviewed_by'];
            const approvedBy = result['Result']['0']['approved_by'];
            const memoapprovedBy = result['Result']['0']['memo_approved_by'];
            const issuedBy = result['Result']['0']['issued_by'];

            // Function to format date-time as "YYYY-MM-DD HH:MM:SS"
            function formatDateTime(dateTime) {
                const dateObj = new Date(dateTime);
                const year = dateObj.getFullYear();
                const month = String(dateObj.getMonth() + 1).padStart(2, '0');
                const day = String(dateObj.getDate()).padStart(2, '0');
                const hours = String(dateObj.getHours()).padStart(2, '0');
                const minutes = String(dateObj.getMinutes()).padStart(2, '0');
                const seconds = String(dateObj.getSeconds()).padStart(2, '0');
                return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
            }

            reviewedTime = formatDateTime(reviewedTime);
            approvedTime = formatDateTime(approvedTime);
            memoapprovedTime = formatDateTime(memoapprovedTime);
            issuedTime = formatDateTime(issuedTime);

            function updateStatusBoxes(status) {

                const allBoxes = document.querySelectorAll('.statusBox');
                allBoxes.forEach(box => {
                    box.classList.remove('bg-soft-success', 'bg-soft-warning', 'bg-soft-secondary');
                    box.querySelector('.details').style.display = 'none';
                });

                if (memostatusid === 'N') {
                    document.getElementById('appendixAReview').classList.add('bg-soft-warning');
                    document.getElementById('appendixAApproval').classList.add('bg-soft-secondary');
                    document.getElementById('memoApproval').classList.add('bg-soft-secondary');
                    document.getElementById('issueToScholar').classList.add('bg-soft-secondary');
                }
                else if (memostatusid === 'SAA') {
                    document.getElementById('appendixAReview').classList.add('bg-soft-success');
                    document.getElementById('appendixAApproval').classList.add('bg-soft-warning');
                    document.getElementById('memoApproval').classList.add('bg-soft-secondary');
                    document.getElementById('issueToScholar').classList.add('bg-soft-secondary');

                    document.getElementById('appendixAReview').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAReview').textContent = reviewedBy;
                    document.getElementById('dateAReview').textContent = reviewedTime;
                    document.getElementById('appendixAApproval').querySelector('.details').style.display = 'none';
                    document.getElementById('memoApproval').querySelector('.details').style.display = 'none';
                    document.getElementById('issueToScholar').querySelector('.details').style.display = 'none';
                }
                else if (memostatusid === 'AAA') {
                    document.getElementById('appendixAReview').classList.add('bg-soft-success');
                    document.getElementById('appendixAApproval').classList.add('bg-soft-success');
                    document.getElementById('memoApproval').classList.add('bg-soft-warning');
                    document.getElementById('issueToScholar').classList.add('bg-soft-secondary');

                    document.getElementById('appendixAReview').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAReview').textContent = reviewedBy;
                    document.getElementById('dateAReview').textContent = reviewedTime;
                    document.getElementById('appendixAApproval').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAApproval').textContent = approvedBy;
                    document.getElementById('dateAApproval').textContent = approvedTime;
                    document.getElementById('memoApproval').querySelector('.details').style.display = 'none';
                    document.getElementById('issueToScholar').querySelector('.details').style.display = 'none';
                }
                else if (memostatusid === 'AM') {
                    document.getElementById('appendixAReview').classList.add('bg-soft-success');
                    document.getElementById('appendixAApproval').classList.add('bg-soft-success');
                    document.getElementById('memoApproval').classList.add('bg-soft-success');
                    document.getElementById('issueToScholar').classList.add('bg-soft-warning');

                    document.getElementById('appendixAReview').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAReview').textContent = reviewedBy;
                    document.getElementById('dateAReview').textContent = reviewedTime;
                    document.getElementById('appendixAApproval').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAApproval').textContent = approvedBy;
                    document.getElementById('dateAApproval').textContent = approvedTime;
                    document.getElementById('memoApproval').querySelector('.details').style.display = 'block';
                    document.getElementById('nameMemoApproval').textContent = memoapprovedBy;
                    document.getElementById('dateMemoApproval').textContent = memoapprovedTime;
                    document.getElementById('issueToScholar').querySelector('.details').style.display = 'none';
                }
                else if (memostatusid === 'R') {
                    document.getElementById('appendixAReview').classList.add('bg-soft-success');
                    document.getElementById('appendixAApproval').classList.add('bg-soft-success');
                    document.getElementById('memoApproval').classList.add('bg-soft-success');
                    document.getElementById('issueToScholar').classList.add('bg-soft-success');

                    document.getElementById('appendixAReview').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAReview').textContent = reviewedBy;
                    document.getElementById('dateAReview').textContent = reviewedTime;
                    document.getElementById('appendixAApproval').querySelector('.details').style.display = 'block';
                    document.getElementById('nameAApproval').textContent = approvedBy;
                    document.getElementById('dateAApproval').textContent = approvedTime;
                    document.getElementById('memoApproval').querySelector('.details').style.display = 'block';
                    document.getElementById('nameMemoApproval').textContent = memoapprovedBy;
                    document.getElementById('dateMemoApproval').textContent = memoapprovedTime;
                    document.getElementById('issueToScholar').querySelector('.details').style.display = 'block';
                    document.getElementById('nameIssueToScholar').textContent = issuedBy;
                    document.getElementById('dateIssueToScholar').textContent = issuedTime;
                }
            }

            updateStatusBoxes(memostatusid);
        }
    });
});
