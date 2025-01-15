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
    tableBody.innerHTML = ''; // Mevcut içeriði temizle
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
        console.log(students); // Yanýtý kontrol edin
        updateStudentTable(students);
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const formElement = document.querySelector('#deleteForm');

    // Form gönderildiðinde çalýþacak iþlev
    formElement.addEventListener('submit', async (event) => {
        event.preventDefault(); // Sayfanýn yeniden yüklenmesini önle

        // Formdan ID deðerini al
        const studentId = formElement.querySelector('#studentIdToDelete').value;

        try {
            // HTTP DELETE isteði gönder
            const response = await fetch(`https://localhost:5001/api/students/${studentId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json' // Ýsteðin içeriði JSON formatýnda
                }
            });

            if (response.ok) {
                console.log('Baþarýyla silindi!');
                // Baþarý durumunda kullanýcýya bildirimde bulunabilir veya sayfayý güncelleyebilirsiniz
                // Örneðin, modal kapatýlabilir ve tablo yeniden yüklenebilir
                $('#exampleModal4').modal('hide'); // Bootstrap modal'ýný kapatma
            } else if (response.status === 404) {
                console.error('Öðrenci bulunamadý.');
                // Hata mesajýný kullanýcýya gösterebilirsiniz
            } else {
                console.error('Silme iþlemi baþarýsýz oldu.');
                // Hata mesajýný kullanýcýya gösterebilirsiniz
            }
        } catch (error) {
            console.error('Hata oluþtu:', error);
        }
    });
});



   
