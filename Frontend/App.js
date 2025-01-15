document.addEventListener('DOMContentLoaded', () => {
    const getListButton = document.querySelector('[data-bs-toggle="modal"]');
    if (getListButton) {
        getListButton.addEventListener('click', fetchStudentList);
    }
});

async function fetchStudentList() {
    try {
        const response = await fetch('https://localhost:7245/api/Students/GetList'); // API URL'nizi buraya ekleyin
        if (!response.ok) {
            throw new Error('Network response was not ok.');
        }
        const students = await response.json();
        updateStudentTable(students);
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

function updateStudentTable(students) {
    const tableBody = document.getElementById('studentTableBody');
    tableBody.innerHTML = ''; // Mevcut i�eri�i temizle
    students.forEach(student => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${student.username || 'N/A'}</td>
            <td>${student.name || 'N/A'}</td>
            <td>${student.surname || 'N/A'}</td>
            <td>${student.studentIdNumber || 'N/A'}</td>
            <td>${student.class || 'N/A'}</td>
            <td>${student.email || 'N/A'}</td>
            <td>${student.phone || 'N/A'}</td>
            <td>${new Date(student.dateOfBirth).toLocaleDateString() || 'N/A'}</td>
            <td>${student.address || 'N/A'}</td>
        `;
        tableBody.appendChild(row);
    });
}

async function fetchStudentList() {
    try {
        const response = await fetch('https://localhost:7245/api/students/GetList');
        if (!response.ok) {
            throw new Error('Network response was not ok.');
        }
        const students = await response.json();
        console.log(students); // Yan�t� kontrol edin
        updateStudentTable(students);
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const formElement = document.querySelector('#deleteForm');

    // Form g�nderildi�inde �al��acak i�lev
    formElement.addEventListener('submit', async (event) => {
        event.preventDefault(); // Sayfan�n yeniden y�klenmesini �nle

        // Formdan ID de�erini al
        const studentId = formElement.querySelector('#studentIdToDelete').value;

        try {
            // HTTP DELETE iste�i g�nder
            const response = await fetch(`https://localhost:5001/api/students/${studentId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json' // �ste�in i�eri�i JSON format�nda
                }
            });

            if (response.ok) {
                console.log('Ba�ar�yla silindi!');
                // Ba�ar� durumunda kullan�c�ya bildirimde bulunabilir veya sayfay� g�ncelleyebilirsiniz
                // �rne�in, modal kapat�labilir ve tablo yeniden y�klenebilir
                $('#exampleModal4').modal('hide'); // Bootstrap modal'�n� kapatma
            } else if (response.status === 404) {
                console.error('��renci bulunamad�.');
                // Hata mesaj�n� kullan�c�ya g�sterebilirsiniz
            } else {
                console.error('Silme i�lemi ba�ar�s�z oldu.');
                // Hata mesaj�n� kullan�c�ya g�sterebilirsiniz
            }
        } catch (error) {
            console.error('Hata olu�tu:', error);
        }
    });
});



   
